using AutoMapper;
using Skynetz.Application.DTOs;
using Skynetz.Application.Interfaces;
using Skynetz.Application.Mappings;
using Skynetz.Domain.Entities;
using Skynetz.Infra.Data.Repositories;
using System.Collections.Generic;

namespace Skynetz.Application.Services
{
    public class FlatRateService : IFlatRateService
    {
        private readonly FlatRateRepository _flatRateRepository;
        private readonly DomainToDTOMappingProfile _mapper;

        public FlatRateService()
        {
            _mapper = new DomainToDTOMappingProfile();
            _flatRateRepository = new FlatRateRepository();
        }

        public void Add(FlatRateDTO flatRateDTO)
        {
            var flatRateEntity = Mapper.Map<FlatRate>(flatRateDTO);
            _flatRateRepository.Create(flatRateEntity);
        }

        public FlatRateDTO GetById(int? id)
        {
            var flatEntity = _flatRateRepository.GetById(id);
            return Mapper.Map<FlatRateDTO>(flatEntity);
        }

        public IEnumerable<FlatRateDTO> GetByOriginAndDestiny(string origin, string destiny)
        {
            var flatRateRepositories = _flatRateRepository.GetByOriginAndDestiny(origin, destiny);
            return Mapper.Map<IEnumerable<FlatRateDTO>>(flatRateRepositories);
        }

        public IEnumerable<FlatRateDTO> GetFlatRates()
        {          
            var flatRateRepositories = _flatRateRepository.GetFlatRate();
            return Mapper.Map<IEnumerable<FlatRateDTO>>(flatRateRepositories);
        }

        public void Remove(int? id)
        {
            var flatEntity = _flatRateRepository.GetById(id);
            _flatRateRepository.Remove(flatEntity);
        }

        public void Update(FlatRateDTO flatRateDTO)
        {
            var flatEntity = Mapper.Map<FlatRate>(flatRateDTO);
            _flatRateRepository.Update(flatEntity);
        }
    }
}