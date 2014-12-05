using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmb
{
    // This class ideally needs to be made dead.
    class TypeSafeRawList<T>
    { 
        private List<Type> lists = new List<Type>();

        public T Find(string Search) 
        {
            foreach (Type t in lists) {
                if (t.Name.Equals(Search)) { 
                    return (T) Activator.CreateInstance(t);
                }
            }

            throw new HttpException(404);
        } 

        public void Register(Type t)
        {
            lists.Add(t); 
        }
    }
}
