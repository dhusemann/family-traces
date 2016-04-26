using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Family_Traces
{
    public class History
    {
        private ArrayList historyIds = new ArrayList();

        public void Add(int id)
        {
            historyIds.Add(id);
        }

        public int Back()
        {
            int val = -1;

            if (historyIds.Count > 1)
            {
                val = (int)(historyIds[historyIds.Count - 2]);
                historyIds.RemoveAt(historyIds.Count - 1);
                historyIds.RemoveAt(historyIds.Count - 1);
            }
            return val;
        }

        public int Current()
        {
            int val = -1;

            if (historyIds.Count > 0)
            {
                val = (int)(historyIds[historyIds.Count - 2]);
                historyIds.RemoveAt(historyIds.Count - 1);
            }
            return val;
        }

        public bool IsEmpty()
        {
            if (historyIds.Count < 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
