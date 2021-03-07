package br.com.richardeveloper.models.dto;

import java.io.Serializable;

import br.com.richardeveloper.models.Owner;
import br.com.richardeveloper.models.Vehicle;

public class VehicleWrapperDto implements Serializable{
	private static final long serialVersionUID = 1L;
	
	private Vehicle vehicle;
	private Owner owner;

	public VehicleWrapperDto(Vehicle vehicle, Owner owner) {
		this.vehicle = vehicle;
		this.owner = owner;
	}
	
	public Vehicle getVeiculo() {
		return vehicle;
	}

	public void setVeiculo(Vehicle vehicle) {
		this.vehicle = vehicle;
	}

	public Owner getOwner() {
		return owner;
	}

	public void setOwner(Owner owner) {
		this.owner = owner;
	}

	
	

}
