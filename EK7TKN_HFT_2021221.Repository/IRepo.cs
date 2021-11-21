using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Repository
{
    public interface IRepo
    {
        public void Create(string filename);
        public void Read();
        public void Update();
        public void Delete();

    }
}
