using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Symbols
{
    public class QualifiedName : IEnumerable<Name>, ICloneable
    {
        public const char SEPARATOR = '.';

        public Name Head { get; protected set; }

        public QualifiedName Tail { get; protected set; }

        public QualifiedName()
        {

        }

        public QualifiedName(Name name)
        {
            int pos = name.Value.IndexOf(QualifiedName.SEPARATOR);

            if (pos > 0)
            {
                Head = name.Value.Substring(0, pos);
                if (pos < name.Value.Length - 1)
                {
                    Tail = new QualifiedName(name.Value.Substring(pos + 1));
                }
            }
            else
            {
                Head = name;
            }
        }

        public static implicit operator QualifiedName(string name)
        {
            return new QualifiedName(name);
        }

        /* dla bezpieczeństwa usuwam te metody, ponieważ przez nie może powstać wiele łańcuchów opartych o te same ogony
        public QualifiedName(QualifiedName qn)
        {
            Head = qn.Head;
            Tail = qn.Tail;
        }

        public QualifiedName(Name head, QualifiedName tail) : this(head)
        {
            Tail = tail;
        }
        */
        /* kopia tego co poniżej, zmienione
        public QualifiedName Append(QualifiedName name)
        {
            if (Tail == null)
            {
                Tail = name;
            }
            else
            {
                Tail.Append(name);
            }

            return this;
        }

        public QualifiedName Prepend(QualifiedName name)
        {
            QualifiedName qn = new QualifiedName();
            qn.Head = Head;
            qn.Tail = Tail;
            Head = name.Head;
            Tail = qn;
            return this;
        }
        */

        public static implicit operator QualifiedName(Name name)
        {
            return new QualifiedName(name);
        }

        public QualifiedName Append(Name name)
        {
            if (Head == null)
            {
                Head = name;
            }
            else if (Tail == null)
            {
                Tail = new QualifiedName(name);
            }
            else
            {
                Tail.Append(name);
            }

            return this;
        }

        public QualifiedName Prepend(Name name)
        {
            QualifiedName qn = new QualifiedName();
            qn.Head = Head;
            qn.Tail = Tail;
            Head = name;
            Tail = qn;
            return this;
        }

        public void PopBack()
        {
            if (Tail == null)
            {
                Head = null;
            }
            else
            {
                QualifiedName node = this;
                while (node != null)
                {
                    if (node.Tail.Tail == null)
                    {
                        break;
                    }
                    node = node.Tail;
                }
                node.Tail = null;
            }
        }

        public Name Back()
        {
            QualifiedName node = this, previous = null;
            while (node != null)
            {
                previous = node;
                node = node.Tail;
            }
            return previous.Head;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Name name in this)
            {
                sb.Append(name.ToString());
                sb.Append(QualifiedName.SEPARATOR);
            }

            sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }

        public static implicit operator string(QualifiedName name)
        {
            return name.ToString();
        }

        public int Length
        {
            get
            {
                int parts = 0;
                QualifiedName node = this;
                while (node != null)
                {
                    if (node.Head == null)
                    {
                        break;
                    }
                    ++parts;
                    node = node.Tail;
                }
                return parts;
            }
        }

        public IEnumerator<Name> GetEnumerator()
        {
            QualifiedName node = this;
            while (node != null)
            {
                if (node.Head == null)
                {
                    yield break;
                }

                yield return node.Head;

                node = node.Tail;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public object Clone()
        {
            QualifiedName copy = new QualifiedName(Head);
            if (Tail != null)
            {
                copy.Tail = (QualifiedName)((ICloneable)Tail).Clone();
            }
            return copy;
        }
    }
}
