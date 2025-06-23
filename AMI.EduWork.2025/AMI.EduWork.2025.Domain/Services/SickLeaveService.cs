using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Interfaces.Service;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Services {
    public class SickLeaveServic : ISickLeaveService {

        private readonly ISickLeaveService _repository;
        private readonly ILogger<SickLeaveServic> _logger;

        public SickLeaveServic(ISickLeaveService repository, ILogger<SickLeaveServic> logger) {
            _repository = repository;
            _logger = logger;
        }

        public Task Create(SickLeave entity) {
            throw new NotImplementedException();
        }

        public Task Delete(string id) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SickLeave>> GetAllByDate(DateOnly startDate, DateOnly endDate) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SickLeave>> GetAllByDateForUser(string userId, DateOnly startDate, DateOnly endDate) {
            throw new NotImplementedException();
        }

        public Task<SickLeave> GetById(string id) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SickLeave>> GetByUserId(string userId) {
            throw new NotImplementedException();
        }

        public Task Update(SickLeave entity) {
            throw new NotImplementedException();
        }
    }
}
