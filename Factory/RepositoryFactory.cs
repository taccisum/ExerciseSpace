using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;
using Practice.Unit;
using Repository.GenericRepository;

namespace Factory
{
    public class RepositoryFactory
    {
        private Dictionary<string, object> _units;
        public RepositoryFactory()
        {
            _units = new Dictionary<string, object>();
        }


        public IGenericRepository<TModel> At<TModel>() where TModel : DTO
        {
            var key = typeof (TModel).FullName;

            if (_units.ContainsKey(key))
            {
                return (IGenericRepository<TModel>) _units[key];
            }
            else
            {
                var unit = new GenericRepository<TModel>();
                _units.Add(key, unit);

                return unit;
            }
        }
    }
}
