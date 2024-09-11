using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMgmt.Interface
{
    public interface IOperationManager
    {
        void StartOperation(int operationId);
        //void AddOperation();
        //void RemoveOperation();
        //void UpdateOperation();
    }
}