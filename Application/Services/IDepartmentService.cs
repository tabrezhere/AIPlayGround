public interface IDepartmentService
{
    Task<DepartmentDto> GetDepartmentByIdAsync(int id);
    Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync();
    Task AddDepartmentAsync(DepartmentDto departmentDto);
    Task UpdateDepartmentAsync(DepartmentDto departmentDto);
    Task DeleteDepartmentAsync(int id);
}