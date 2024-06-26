using System;


namespace DeqSort
{
    public class Deque
    {
        public static long Nop = 0;
        private protected Item left = null;                        //1
        private protected Item right = null;                       //1
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  

        public bool IsEmpty()                                      //2
        {
            Nop += 2;
            return left == null;
        }

        public void PushLeft(Item newItem)                         //8
        {
            Nop+=3;
            if (IsEmpty())                                         //2
            {
                Nop += 2;
                left = newItem;                                    //1
                right = newItem;                                   //1
            }
            else
            {
                Nop += 3;
                newItem.next = left;                               //1
                left.prev = newItem;                               //1
                left = newItem;                                    //1
            }
        }

        public void PushRight(Item newItem)                        //8
        {
            Nop += 3;
            if (IsEmpty())                                         //2
            {
                Nop += 2;
                left = newItem;                                    //1    
                right = newItem;                                   //1
            }
            else
            {
                Nop += 3;
                newItem.prev = right;                              //1
                right.next = newItem;                              //1
                right = newItem;                                   //1
            }
        }
        
        public Item PopLeft()                                      //9
        {
            Nop+=2;
            if (IsEmpty())                                         //2
            {
                Nop++;
                throw new Exception("Deque is empty");             //1
            }

            Nop += 2;
            Item result = left;                                    //1
            left = left.next;                                      //1
            Nop++;
            if (left == null)                                      //1
            {
                Nop++;
                right = null;                                      //1
            }
            else
            {
                Nop += 1;
                left.prev = null;                                  //1
            }
            Nop += 1;
            return result;                                         //1
        }

        public Item PopRight()                                     //9
        {
            Nop+=2;
            if (IsEmpty())                                         //2
            {
                Nop++;
                throw new Exception("Deque is empty!");            //1
            }

            Nop += 2;
            Item result = right;                                   //1 
            right = right.prev;                                    //1
            Nop++;
            if (right == null)                                     //1
            {
                Nop++;                                                                                                                                                                                                                      
                left = null;                                       //1
            }
            else
            {
                Nop++;
                right.next = null;                                 //1
            }
            Nop++;
            return result;                                         //1
        }

        public void Print()
        {
            Nop++;
            Item current = left;
            Nop++;
            while (current != null)                                 
            {
                Console.Write(current.value + " ");                
                current = current.next;
                Nop+=2;
            }
            Console.WriteLine();
            Nop++;                                                                                                                                                                                                   
            
        }

        
    }

    public class Sort : Deque
    {
         
        public static void SelectionSort(int N, Sort deque)         //
        {
            int min, temp;
            Deque.Nop++;
            for (int i = 0; i < N - 1; i++)                         //
            {
                min = i;                                            //1
                Deque.Nop++;
                Deque.Nop++;
                for (int j = i + 1; j < N; j++)                     //
                {
                    Deque.Nop++;
                    if (deque[j] < deque[min])                      //
                    {
                        min = j;                                    //1
                        Deque.Nop++;
                    }
                    
                    Deque.Nop+=2;
                }

                temp = deque[i];                                    //
                deque[i] = deque[min];                              // 
                deque[min] = temp;                                  //
                Deque.Nop += 3;
                Deque.Nop += 2;
            }
        }

        public int Get(int pos, Sort tmp)                           //
        {
            Deque.Nop+=2;
            if (IsEmpty())                                         //2
            {
                Deque.Nop++;
                throw new Exception("Deque is empty");             //1
            }
            Deque.Nop++;
            for (int i = 0; i < pos; i++)                          //
            {
                tmp.PushRight(PopLeft());                          //17
                Deque.Nop += 2;
            }
            Deque.Nop++;
            int result = left.value;                               //1

            Deque.Nop += 2;
            for (int i = 0; i < pos; i++)                                //
            {
                PushLeft(tmp.PopRight());                          //17
            }

            Deque.Nop++;
            return result;                                         //1

        }

        public void Set(int pos, int newValue, Sort tmp)            //
        {
            Deque.Nop+=2;
            if (IsEmpty())                                          //2
            {
                Deque.Nop++;
                throw new Exception("Deque is empty");              //1
            }
            Deque.Nop++;
            for (int i = 0; i < pos; i++)                           //
            {
                tmp.PushRight(PopLeft());                           //17
                Deque.Nop += 2;
            }
            Deque.Nop++;
            left.value = newValue;                                  //1

            Deque.Nop +=2;
            for (int i = 0; i < pos; i++)                                  //
            {
                PushLeft(tmp.PopRight());                           //17
            }
            

        }

        public int this[int index]                                  //1
        {
 
            get => Get(index, new Sort());                          //
            set => Set(index, value, new Sort());                   //
        }


    }
}
