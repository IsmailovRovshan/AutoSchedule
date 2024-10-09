using AutoMapper;
using Contracts;
using Domain.Entities;
using Domain.Repository;
using Services.Abstractions;

namespace Services
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;

        public LessonService(
            ILessonRepository lessonRepository,
            IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

        public async Task<LessonDto> CreateAsync(LessonDtoForCreate lessonDto)
        {
            var lesson = _mapper.Map<Lesson>(lessonDto);
            await _lessonRepository.AddAsync(lesson);
            return _mapper.Map<LessonDto>(lesson);
        }

        public async Task DeleteAsync(Guid lessonId)
        {
            var lesson = await _lessonRepository.GetByIdAsync(lessonId);
            if (lesson == null)
            {
                throw new KeyNotFoundException("Урок не найден.");
            }
            await _lessonRepository.DeleteAsync(lesson);
        }

        public async Task<List<LessonDto>> GetAllAsync()
        {
            var lessons = await _lessonRepository.GetAllAsync();
            return _mapper.Map<List<LessonDto>>(lessons);
        }

        public async Task<LessonDto> GetByIdAsync(Guid lessonId)
        {
            var lesson = await _lessonRepository.GetByIdAsync(lessonId);
            if (lesson == null)
            {
                throw new KeyNotFoundException("Урок не найден.");
            }
            return _mapper.Map<LessonDto>(lesson);
        }

        public async Task UpdateAsync(Guid lessonId, LessonDtoForUpdate lessonDto)
        {
            var lesson = await _lessonRepository.GetByIdAsync(lessonId);

            if (lesson == null)
            {
                throw new KeyNotFoundException("Урок не найден.");
            }

            _mapper.Map(lessonDto, lesson);

            await _lessonRepository.UpdateAsync(lesson);
        }
    }
}
