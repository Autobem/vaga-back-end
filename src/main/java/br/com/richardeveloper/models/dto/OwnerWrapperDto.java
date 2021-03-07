package br.com.richardeveloper.models.dto;

import java.util.ArrayList;
import java.util.List;

import br.com.richardeveloper.models.Owner;
import br.com.richardeveloper.models.Vehicle;

public class OwnerWrapperDto {

	private Owner owner;
	private List<Vehicle> vehicles = new ArrayList<Vehicle>();
	
	public OwnerWrapperDto(Owner owner, List<Vehicle> vehicles) {
		this.owner = owner;
		this.vehicles = vehicles;
	}
	public Owner getOwner() {
		return owner;
	}
	public void setOwner(Owner owner) {
		this.owner = owner;
	}
	public List<Vehicle> getVehicles() {
		return vehicles;
	}
	public void setVehicles(List<Vehicle> vehicles) {
		this.vehicles = vehicles;
	}
	
	
	
}
