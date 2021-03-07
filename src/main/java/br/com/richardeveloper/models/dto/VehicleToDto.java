package br.com.richardeveloper.models.dto;

import java.util.List;
import java.util.stream.Collectors;

import br.com.richardeveloper.models.Vehicle;

public class VehicleToDto {

	public static VehicleDto entityToDto(Vehicle vehicle) {
		VehicleDto dto = new VehicleDto(vehicle);
		return dto;
	}
	
	public static List<VehicleDto> listToListDto(List<Vehicle> vehicles){
		List<VehicleDto> listDto = vehicles.stream().map( (obj) -> entityToDto(obj)).collect(Collectors.toList());
		return listDto;
	}
	
}
