using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Composite
{
    public abstract class FileSystemElement
    {
        public abstract int GetCount { get; }
        public string Name { get; set; }
        public FileSystemElement(string name)
        {
            Name = name;    
        }
    }
    public class DirectoryElement : FileSystemElement
    {
        public DirectoryElement(string name) : base(name)
        {
        }
        private List<FileSystemElement> Elements = new();
        public void Add(FileSystemElement element) => Elements.Add(element);
        public void Remove(FileSystemElement element) => Elements.RemoveAll(x => x.Name == element.Name);

        public override int GetCount => throw new NotImplementedException();
    }
}
