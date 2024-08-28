using FitnessAppAPI.IRepositories;
using FitnessAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.Repositories
{
    public class MembershipRepository : IMembershipRepository
    {
        private readonly FitnessHubContext _context;

        public MembershipRepository(FitnessHubContext context)
        {
            _context = context;
        }

        public void AddMembership(Membership membership)
        {
            
            _context.Memberships.Add(membership);
            _context.SaveChanges();
        }


        public void DeleteMembership(int id)
        {
            var membership= _context.Memberships.FirstOrDefault(x => x.Id == id);
            if(membership != null)
            {
                _context.Memberships.Remove(membership);
                _context.SaveChanges();
            }
        }

        public Membership GetMembershipById(int id)
        {
            return _context.Memberships.FirstOrDefault(m=>m.Id == id);
        }

        public IEnumerable<Membership> GetMembershipsByUserId(int userId)
        {
            return _context.Memberships.Where(m=>m.UserId== userId).ToList();
        }

        public void UpdateMembership(Membership membership)
        {
            var existingMembership= _context.Memberships.FirstOrDefault(m=>m.Id==membership.Id);
            if (existingMembership == null)
            {
                throw new InvalidOperationException("Membership not found!");
            }
            _context.Entry(existingMembership).CurrentValues.SetValues(membership);
            _context.SaveChanges();
        }
    }
}