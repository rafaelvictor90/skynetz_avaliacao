using AutoMapper;
using Skynetz.Application.DTOs;
using Skynetz.Application.Interfaces;
using Skynetz.Application.Mappings;
using Skynetz.Domain.Entities;
using Skynetz.Infra.Data.Repositories;
using System;
using System.Collections.Generic;

namespace Skynetz.Application.Services
{
    public class PlanFaleMaisService : IPlanFaleMaisService
    {
        private readonly PlanFaleMaisRepository _planFaleMaisRepository;
        private readonly FlatRateRepository _flatRateRepository;
        private readonly DomainToDTOMappingProfile _mapper;

        public PlanFaleMaisService()
        {
            _mapper = new DomainToDTOMappingProfile();
            _planFaleMaisRepository = new PlanFaleMaisRepository();
            _flatRateRepository = new FlatRateRepository();
        }

        public void Add(PlanFaleMaisDTO planFaleMaisDTO)
        {
            var planFaleMaisEntity = Mapper.Map<PlanFaleMais>(planFaleMaisDTO);
            _planFaleMaisRepository.Create(planFaleMaisEntity);
        }

        public PlanFaleMaisDTO GetById(int? id)
        {
            var planFaleMaisEntity = _planFaleMaisRepository.GetById(id);
            return Mapper.Map<PlanFaleMaisDTO>(planFaleMaisEntity);
        }

        public IEnumerable<PlanFaleMaisDTO> GetPlanFaleMais()
        {
            var planFaleMaisEntities = _planFaleMaisRepository.GetPlanFaleMais();
            return Mapper.Map<IEnumerable<PlanFaleMaisDTO>>(planFaleMaisEntities);
        }

        public void Remove(int? id)
        {
            var planFaleMaisEntity = _planFaleMaisRepository.GetById(id);
            _planFaleMaisRepository.Remove(planFaleMaisEntity);
        }

        public void Update(PlanFaleMaisDTO planFaleMaisDTO)
        {
            var planFaleMaisEntity = Mapper.Map<PlanFaleMais>(planFaleMaisDTO);
            _planFaleMaisRepository.Update(planFaleMaisEntity);
        }

        public IEnumerable<PlanFaleMaisDTO> GetBySearch(string origin, string destiny, int minutes, int idFalaMais)
        {
            var flatRates = _flatRateRepository.GetByOriginAndDestiny(origin, destiny);
            var planFalaMaisEntity = _planFaleMaisRepository.GetById(idFalaMais);

            var result = new List<PlanFaleMaisDTO>();

            var planFalaMais = new PlanFaleMaisDTO();
            planFalaMais.Origin = origin;
            planFalaMais.Destiny = destiny;
            planFalaMais.MinuteTime = minutes;
            planFalaMais.Name = planFalaMaisEntity.Name;

            foreach (var flatRate in flatRates)
            {
                int minutesTemp = minutes - planFalaMaisEntity.MinuteTime;

                if (minutesTemp < 0)
                    planFalaMais.WithFalaMais = "-";
                else
                    planFalaMais.WithFalaMais = string.Format("R$ {0}"
                        , (Convert.ToDecimal(minutesTemp * flatRate.MinuteValue)) * 1.1m).Replace('.', ',');

                planFalaMais.WithoutFalaMais = string.Format("R$ {0}", minutes * flatRate.MinuteValue).Replace('.', ',');

                result.Add(planFalaMais);
            }

            if (result.Count == 0)
            {
                planFalaMais.WithFalaMais = "-";
                planFalaMais.WithoutFalaMais = "-";
                result.Add(planFalaMais);
            }

            return result;
        }
    }
}