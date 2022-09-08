using System;

namespace Dythervin.Data.Structs
{

    public struct FixedArray2<T>
    {
        public T item0;
        public T item1;

        public int Count => 2;

        public T this[int index]
        {
            get
            {
                switch(index)
                {

                    case 0: return item0;
                    case 1: return item1;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
            set
            {                
                switch(index)
                {

                    case 0:
                        item0 = value;
                        break;
                    case 1:
                        item1 = value;
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
        }
    }

    public struct FixedArray3<T>
    {
        public T item0;
        public T item1;
        public T item2;

        public int Count => 3;

        public T this[int index]
        {
            get
            {
                switch(index)
                {

                    case 0: return item0;
                    case 1: return item1;
                    case 2: return item2;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
            set
            {                
                switch(index)
                {

                    case 0:
                        item0 = value;
                        break;
                    case 1:
                        item1 = value;
                        break;
                    case 2:
                        item2 = value;
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
        }
    }

    public struct FixedArray4<T>
    {
        public T item0;
        public T item1;
        public T item2;
        public T item3;

        public int Count => 4;

        public T this[int index]
        {
            get
            {
                switch(index)
                {

                    case 0: return item0;
                    case 1: return item1;
                    case 2: return item2;
                    case 3: return item3;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
            set
            {                
                switch(index)
                {

                    case 0:
                        item0 = value;
                        break;
                    case 1:
                        item1 = value;
                        break;
                    case 2:
                        item2 = value;
                        break;
                    case 3:
                        item3 = value;
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
        }
    }

    public struct FixedArray5<T>
    {
        public T item0;
        public T item1;
        public T item2;
        public T item3;
        public T item4;

        public int Count => 5;

        public T this[int index]
        {
            get
            {
                switch(index)
                {

                    case 0: return item0;
                    case 1: return item1;
                    case 2: return item2;
                    case 3: return item3;
                    case 4: return item4;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
            set
            {                
                switch(index)
                {

                    case 0:
                        item0 = value;
                        break;
                    case 1:
                        item1 = value;
                        break;
                    case 2:
                        item2 = value;
                        break;
                    case 3:
                        item3 = value;
                        break;
                    case 4:
                        item4 = value;
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}