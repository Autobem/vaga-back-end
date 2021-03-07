package br.com.richardeveloper.models.dto;

import br.com.richardeveloper.enums.Category;
import br.com.richardeveloper.models.Vehicle;

public class VehicleDto {

	private Long id;
	private String model;
	private String brand;
	private Integer modelYear;
	private Category category;
	
	public VehicleDto(Vehicle veiculo) {
		this.id = veiculo.getId();
		this.model = veiculo.getModel();
		this.brand = veiculo.getBrand();
		this.modelYear = veiculo.getModelYear();
		this.category = veiculo.getCategory();
	}

	public Long getId() {
		return id;
	}

	public String getModel() {
		return model;
	}

	public String getBrand() {
		return brand;
	}

	public Integer getModelYear() {
		return modelYear;
	}

	public Category getCategory() {
		return category;
	}
	
}
