using FitnessAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAppAPI.IRepositories
{
    public interface IMembershipRepository
    {
        Membership GetMembershipById(int id);
        IEnumerable<Membership> GetMembershipsByUserId(int userId);
        void AddMembership(Membership membership);
        void UpdateMembership(Membership membership);
        void DeleteMembership(int id);



    }
}
