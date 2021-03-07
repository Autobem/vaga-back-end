package br.com.richardeveloper.models.dto;

import java.util.List;
import java.util.stream.Collectors;

import br.com.richardeveloper.models.Owner;

public class OwnerToDto {

	public static OwnerDto entityToDto(Owner owner) {
		OwnerDto dto = new OwnerDto(owner);
		return dto;
	}
	
	public static List<OwnerDto> listToListDto(List<Owner> owners){
		List<OwnerDto> listDto = owners.stream().map( (obj) -> entityToDto(obj)).collect(Collectors.toList());
		return listDto;
	}
	
}
