namespace Inventario.Dtos;

public class StoreDto
{
	public string? code { get; set; }
	public string? description { get; set; }
	public int? company_id { get; set; }

	public bool paginate { get; set; } = false;
	public int perPage { get; set; } = 10;
	public int page { get; set; } = 1;
}