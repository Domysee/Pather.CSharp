using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pather.CSharp
{
    public class SelectionEnumerator : IEnumerator, IEnumerator<object>
    {
        private Selection selection;
        private int currentIndex;

        public SelectionEnumerator(Selection selection)
        {
            this.selection = selection;
            currentIndex = -1;
        }

        public object Current
        {
            get
            {
                lock (selection)
                {
                    if (currentIndex == -1) return null;
                    if (currentIndex >= selection.Entries.Count)
                        throw new InvalidOperationException("The enumerator is past the last element. Call Reset to start again from the first one");
                    return selection.Entries.ElementAt(currentIndex);
                }
            }
        }

        public bool MoveNext()
        {
            currentIndex += 1;
            return currentIndex < selection.Entries.Count;
        }

        public void Reset()
        {
            currentIndex = -1;
        }

        public void Dispose()
        {
        }
    }
}
