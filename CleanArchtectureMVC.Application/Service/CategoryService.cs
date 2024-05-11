using AutoMapper;
using CleanArchtectureMVC.Application.DTOs;
using CleanArchtectureMVC.Application.Interface;
using CleanArchtectureMVC.Domain.Interface;
using CleanArchtectureMVC.Domain.Model;

namespace CleanArchtectureMVC.Application.Service
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            IEnumerable<Category> categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO?> GetByIdAsync(int id)
        {
            Category? category = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task CreateAsync(CategoryDTO categoryDTO)
        {
            Category category = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.CreateAsync(category);
        }

        public async Task UpdateAsync(CategoryDTO categoryDTO)
        {
            Category category = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.UpdateAsync(category);
        }

        public async Task RemoveAsync(int id)
        {
            Category? category = await _categoryRepository.GetByIdAsync(id);
            if(category==null) throw new ArgumentNullException(nameof(category));
            
            await _categoryRepository.RemoveAsync(category);
        }
    }
}