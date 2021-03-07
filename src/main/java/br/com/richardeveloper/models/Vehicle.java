package br.com.richardeveloper.models;

import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;
import javax.validation.constraints.NotEmpty;
import javax.validation.constraints.NotNull;

import com.fasterxml.jackson.annotation.JsonIgnore;

import br.com.richardeveloper.enums.Category;

@Entity
@Table(name = "tb_vehicle")
public class Vehicle {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private Long id;
	
	@NotEmpty(message = "Field model cannot be empty.")
	private String model;
	
	@NotEmpty(message = "Field brand cannot be empty.")
	private String brand;
	
	@NotNull(message = "Field model year cannot be empty.")
	private Integer modelYear;
	
	@NotNull(message = "Field category cannot be empty.")
	private Integer category;
	
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "owner_id")
	@JsonIgnore
	private Owner owner;
	
	public Vehicle() {

	}

	public Vehicle(Long id, String model, String brand, Integer modelYear, Category category) {
		this.id = id;
		this.model = model;
		this.brand = brand;
		this.modelYear = modelYear;
		this.setCategory(category);
	}
	
	public void setId(Long id) {
		this.id = id;
	}

	public Long getId() {
		return id;
	}
	
	public String getModel() {
		return model;
	}

	public void setModel(String model) {
		this.model = model;
	}

	public String getBrand() {
		return brand;
	}

	public void setBrand(String brand) {
		this.brand = brand;
	}

	public Integer getModelYear() {
		return modelYear;
	}

	public void setModelYear(Integer modelYear) {
		this.modelYear = modelYear;
	}

	public Category getCategory() {
		return Category.getCategory(category);
	}

	public void setCategory(Category category) {
		this.category = category.getCode();
	}

	public Owner getOwner() {
		return this.owner;
	}
	
	public void setOwner(Owner owner) {
		this.owner = owner;
	}

	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + ((id == null) ? 0 : id.hashCode());
		return result;
	}

	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		Vehicle other = (Vehicle) obj;
		if (id == null) {
			if (other.id != null)
				return false;
		} else if (!id.equals(other.id))
			return false;
		return true;
	}

	@Override
	public String toString() {
		return "Vehicle [id=" + id + ", model=" + model + ", brand=" + brand + ", modelYear=" + modelYear
				+ ", category=" + category + ", owner=" + owner + "]";
	}
	
}
