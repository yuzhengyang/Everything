using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UsnOperation;

namespace QueryEngine
{
    public class Engine
    {
        /// <summary>
        /// When its values is 1407374883553285(0x5000000000005L), it means this file/folder is under drive root
        /// </summary>
        protected const UInt64 ROOT_FILE_REFERENCE_NUMBER = 0x5000000000005L;

        protected static readonly IEnumerable<string> excludeFolders = 
            new string[]
            {
                "$RECYCLE.BIN",
                "System Volume Information",
                "$AttrDef",
                "$BadClus",
                "$BitMap",
                "$Boot",
                "$LogFile",
                "$Mft",
                "$MftMirr",
                "$Secure",
                "$TxfLog",
                "$UpCase",
                "$Volume",
                "$Extend"
            }.Select(e=>e.ToUpper());

        public static IEnumerable<DriveInfo> GetAllFixedNtfsDrives(string driver = "")
        {
            //return DriveInfo.GetDrives()
            //    .Where(d => d.DriveType == DriveType.Fixed && d.DriveFormat.ToUpper() == "NTFS");
            var dirs = DriveInfo.GetDrives();
            //return dirs.Where(d => d.DriveType == DriveType.Removable && d.DriveFormat.ToUpper() == "NTFS");
            return dirs.Where(d => d.IsReady&& d.Name.ToUpper().Contains(driver.ToUpper()) && d.DriveFormat.ToUpper() == "NTFS");
        }

        public static List<FileAndDirectoryEntry> GetAllFilesAndDirectories(string driver="")
        {
            List<FileAndDirectoryEntry> result = new List<FileAndDirectoryEntry>();

            IEnumerable<DriveInfo> fixedNtfsDrives = GetAllFixedNtfsDrives(driver);

            foreach (var drive in fixedNtfsDrives)
            {
                var usnOperator = new UsnOperator(drive);

                var usnEntries = usnOperator.GetEntries().Where(e => !excludeFolders.Contains(e.FileName.ToUpper()));
                var folders = usnEntries.Where(e => e.IsFolder).ToArray();
                List<FrnFilePath> paths = GetFolderPath(folders, drive);

                result.AddRange(usnEntries.Join(
                    paths,
                    usn => usn.ParentFileReferenceNumber,
                    path => path.FileReferenceNumber,
                    (usn, path) => new FileAndDirectoryEntry(usn, path.Path)));
            }

            //Console.WriteLine(result.Count);
            //Console.WriteLine("==========");
            //for (int i = 0; i < result.Count; i++)
            //{
            //    Console.WriteLine((i) + "、" + result[i].FileName);
            //}
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine((i) + "、" + result[i].FileName);
            //}
            //Console.WriteLine("==========");
            //for (int i = 10; i > 0; i--)
            //{
            //    Console.WriteLine((result.Count - i) + "、" + result[result.Count - i].FileName);
            //}
            return result;
        }

        private static List<FrnFilePath> GetFolderPath(UsnEntry[] folders, DriveInfo drive)
        {
            Dictionary<UInt64, FrnFilePath> pathDic = new Dictionary<ulong, FrnFilePath>();
            pathDic.Add(ROOT_FILE_REFERENCE_NUMBER,
                new FrnFilePath(ROOT_FILE_REFERENCE_NUMBER, null, string.Empty, drive.Name));

            foreach (var folder in folders)
            {
                pathDic.Add(folder.FileReferenceNumber,
                    new FrnFilePath(folder.FileReferenceNumber, folder.ParentFileReferenceNumber, folder.FileName));
            }

            Stack<UInt64> treeWalkStack = new Stack<ulong>();

            foreach (var key in pathDic.Keys)
            {
                treeWalkStack.Clear();

                FrnFilePath currentValue = pathDic[key];

                if (string.IsNullOrWhiteSpace(currentValue.Path)
                    && currentValue.ParentFileReferenceNumber.HasValue
                    && pathDic.ContainsKey(currentValue.ParentFileReferenceNumber.Value))
                {
                    FrnFilePath parentValue = pathDic[currentValue.ParentFileReferenceNumber.Value];

                    while (string.IsNullOrWhiteSpace(parentValue.Path)
                        && parentValue.ParentFileReferenceNumber.HasValue
                        && pathDic.ContainsKey(parentValue.ParentFileReferenceNumber.Value))
                    {
                        var temp = currentValue;
                        currentValue = parentValue;

                        if (currentValue.ParentFileReferenceNumber.HasValue
                            && pathDic.ContainsKey(currentValue.ParentFileReferenceNumber.Value))
                        {
                            treeWalkStack.Push(temp.FileReferenceNumber);
                            parentValue = pathDic[currentValue.ParentFileReferenceNumber.Value];
                        }
                        else
                        {
                            parentValue = null;
                            break;
                        }
                    }

                    if (parentValue != null)
                    {
                        currentValue.Path = BuildPath(currentValue, parentValue);

                        while (treeWalkStack.Count() > 0)
                        {
                            UInt64 walkedKey = treeWalkStack.Pop();

                            FrnFilePath walkedNode = pathDic[walkedKey];
                            FrnFilePath parentNode = pathDic[walkedNode.ParentFileReferenceNumber.Value];

                            walkedNode.Path = BuildPath(walkedNode, parentNode);
                        }
                    }
                }
            }

            var result = pathDic.Values.Where(p => !string.IsNullOrWhiteSpace(p.Path) && p.Path.StartsWith(drive.Name)).ToList();

            return result;
        }

        private static string BuildPath(FrnFilePath currentNode, FrnFilePath parentNode)
        {
            return string.Concat(new string[] { parentNode.Path, "\\", currentNode.FileName });
        }
    }
}
