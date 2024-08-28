using FitnessAppAPI.IRepositories;
using FitnessAppAPI.IServices;
using FitnessAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAppAPI.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IMembershipRepository _repository;

        public MembershipService(IMembershipRepository repository)
        {
            _repository = repository;
        }

        public void AddMembership(Membership membership)
        {

            if (MembershipExists(membership))
            {
                throw new InvalidOperationException("Membership already exist.");
            }

            _repository.AddMembership(membership);
        }


        public void DeleteMembership(int id)
        {
            _repository.DeleteMembership(id);
        }

        public Membership GetMembershipById(int id)
        {
            return _repository.GetMembershipById(id);
        }

        public IEnumerable<Membership> GetMembershipsByUserId(int userId)
        {
            return _repository.GetMembershipsByUserId(userId);
        }

        public void UpdateMembership(Membership membership)
        {
            if (MembershipIdsChanged(membership))
            {
                throw new InvalidOperationException("Membership cannot change ids.");
            }
            _repository.UpdateMembership(membership);
        }

        private bool MembershipExists(Membership membership)
        {
            IEnumerable<Membership> userMemberships = _repository.GetMembershipsByUserId(membership.UserId);
            if (userMemberships.Any(m => m.GymId == membership.GymId))
                return true;
            return false;
        }

        private bool MembershipIdsChanged(Membership membership)
        {
            Membership membershipFound= _repository.GetMembershipById(membership.UserId);
            if(membershipFound.UserId!= membership.UserId || membershipFound.GymId != membership.GymId)
            {
                return true;
            }
            return false;
        }
    }
}