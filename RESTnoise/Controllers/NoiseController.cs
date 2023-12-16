    // Importér de nødvendige namespaces
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using NoiseMeterLib;

    // Dit eksisterende namespace
    namespace RESTnoise.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class NoiseController : ControllerBase
        {
            private NoiseMeterRepository _repository; // Du skal initialisere dette et eller andet sted, f.eks. i konstruktøren.

            // Konstruktør, hvor du kan initialisere dit repository
            public NoiseController(NoiseMeterRepository repository)
            {
                _repository = repository;
            }

            // HTTP GET-metode til at hente alle støjmålere
            [HttpGet]
            public List<NoiseMeter> GetAllNoiseMeters()
            {
                return _repository.GetAll();
            }

            // HTTP GET-metode til at hente den støjmåler med maksimal lydstyrke
            [HttpGet("maxvolume")]
            public NoiseMeter GetMaxVolumeNoiseMeter()
            {
                return _repository.GetMaxVolume();
            }

            // HTTP GET-metode til at filtrere støjmålere efter dato
            [HttpGet("filterbydate")]
            public List<NoiseMeter> FilterNoiseMetersByDate([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
            {
                return _repository.FilterByDate(startDate, endDate);
            }

            // HTTP GET-metode til at kontrollere om rummet er besat baseret på en lydstyrkethreshold
            [HttpGet("isroomoccupied")]
            public bool IsRoomOccupied([FromQuery] double thresholdDbVolume)
            {
                return _repository.IsRoomOccupied(thresholdDbVolume);
            }

            // HTTP PUT-metode til at opdatere alle støjmålere
            [HttpPut("updateall")]
            public void UpdateAllNoiseMeters([FromBody] List<NoiseMeter> updatedNoiseMeters)
            {
                // Du kan tilføje validering eller anden logik her, før du kalder opdateringsmetoden på repository
                _repository.UpdateAll(updatedNoiseMeters);
            }
        }
    }
