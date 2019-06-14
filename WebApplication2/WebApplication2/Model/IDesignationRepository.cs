using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Contracts;

namespace WebApplication2.Model
{
    public interface IDesignationRepository
    {
        List<DesignationContract> GetAllDesignation();
        DesignationContract GetDesignation(int id);
        Designation AddDesignation(Designation designation);
        Designation DeleteDesignation(int id);
    }
}
