using CA_Barbut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_Barbut.Repository
{
    public interface IBalanceRepository
    {
        public int GetById(int id);
        public void PointAdd(Balance balance);
        public void PointRemove(Balance balance);
    }
}
