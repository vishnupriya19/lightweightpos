using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Contracts;

namespace WebApplication2.Model
{
    public class SQLDesignationRepository : IDesignationRepository
    {
        private AppDbContext context;

        public SQLDesignationRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Designation AddDesignation(Designation designation)
        {
            context.Designation.Add(designation);
            context.SaveChanges();
            return designation;
        }

        public Designation DeleteDesignation(int id)
        {
            var des = context.Designation.Find(id);
            if (des != null)
            {
                context.Designation.Remove(des);
                context.SaveChanges();
            }
            return des;
        }

        public DesignationContract GetDesignation(int id)
        {
            var designationVar = context.Designation.FirstOrDefault(e => e.DesignationId == id);
            DesignationContract designationContract = new DesignationContract();
            designationContract.designationId = designationVar.DesignationId;
            designationVar.Name = designationVar.Name;
            return designationContract;
        }

        public List<DesignationContract> GetAllDesignation()
        {
            var designationVar = context.Designation.ToList();
            var designationData = (from data in designationVar
                                   select new DesignationContract
                                   {
                                       designationId = data.DesignationId,
                                       Name = data.Name
                                   }).ToList();
            return designationData;
        }
    }
}
