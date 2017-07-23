using System;
using System.Collections.Generic;
using System.Text;

namespace frep2
{
    class VirtualFundList : IList<Fund>
    {
        public class Enumerator : IEnumerator<Fund>
        {
            private VirtualFundList _Conatainer;
            private List<string>.Enumerator _Enumerator;

            public Fund Current { get { return this._Conatainer._DataBase.Data[this._Enumerator.Current]; } }
            object System.Collections.IEnumerator.Current { get { return this.Current; } }

            public Enumerator(VirtualFundList container)
            {
                this._Conatainer = container;
                this._Enumerator = this._Conatainer._InnerList.GetEnumerator();
            }
            public void Dispose() { }
            public bool MoveNext() { return this._Enumerator.MoveNext(); }
            public void Reset() { }

        }

        DataBase _DataBase;
        List<string> _InnerList;

        public VirtualFundList(DataBase db, List<string> list)
        {
            this._DataBase = db;
            this._InnerList = list;
        }
        public Fund this[int index]
        {
            get { return this._DataBase.Data[this._InnerList[index]]; }
            set { throw new NotImplementedException(); }
        }
        public int Count { get { return this._InnerList.Count; } }

        public bool IsReadOnly { get { return true; } }
        public void Add(Fund item) { throw new NotImplementedException(); }
        public void Clear() { throw new NotImplementedException(); }
        public bool Contains(Fund item) { return this._InnerList.Contains(item.Id); }
        public void CopyTo(Fund[] array, int arrayIndex) { throw new NotImplementedException(); }
        public IEnumerator<Fund> GetEnumerator() { return new Enumerator(this); }
        public int IndexOf(Fund item) { return this._InnerList.IndexOf(item.Id); }
        public void Insert(int index, Fund item) { throw new NotImplementedException(); }
        public bool Remove(Fund item) { throw new NotImplementedException(); }
        public void RemoveAt(int index) { throw new NotImplementedException(); }
        //IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return this.GetEnumerator(); }
    }
}
