using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory;
using log4net;

namespace BLL
{
    public abstract class BaseBusiness
    {
        protected RepositoryFactory RepositoryFactory;
        protected ILog Log;

        protected BaseBusiness()
        {
            RepositoryFactory = new RepositoryFactory();
            Log = LogManager.GetLogger(this.GetType().Name);
        }
    }
}
