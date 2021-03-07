package br.com.richardeveloper.controllers;

import java.util.List;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import br.com.richardeveloper.models.Vehicle;
import br.com.richardeveloper.models.dto.VehicleDto;
import br.com.richardeveloper.models.dto.VehicleToDto;
import br.com.richardeveloper.models.dto.VehicleWrapperDto;
import br.com.richardeveloper.resources.exceptions.InvalidParametersException;
import br.com.richardeveloper.services.VehicleService;

@RestController
@RequestMapping("/vehicles")
public class VehicleController {

	@Autowired
	private VehicleService service;
	
	@GetMapping(params = { "page", "qtd" })
	public ResponseEntity<Page<VehicleDto>> findAllPagination(@RequestParam(name = "page") int page, @RequestParam(name = "qtd") int qtd){
		Page<Vehicle> vehicles = service.findAllPagination(page, qtd);
		Page<VehicleDto> dto = vehicles.map((obj) -> VehicleToDto.entityToDto(obj));
		return new ResponseEntity<Page<VehicleDto>>(dto, HttpStatus.OK);	
	}
	
	@GetMapping("/{id}")
	public ResponseEntity<VehicleDto> findById(@PathVariable Long id){
		Vehicle vehicle = service.findById(id);
		VehicleDto dto = VehicleToDto.entityToDto(vehicle);
		return new ResponseEntity<VehicleDto>(dto, HttpStatus.OK);
	}
	
	@GetMapping("/brand")
	public ResponseEntity<List<VehicleDto>> findByBrand(@RequestParam(name = "brand") String brand){
		List<Vehicle> vehicles = service.findByBrand(brand);
		List<VehicleDto> dto = VehicleToDto.listToListDto(vehicles);
		return new ResponseEntity<List<VehicleDto>>(dto, HttpStatus.OK);
	}
	
	@GetMapping("/model")
	public ResponseEntity<List<VehicleDto>> findByModel(@RequestParam(name = "model") String model){
		List<Vehicle> vehicles = service.findByModel(model);
		List<VehicleDto> dto = VehicleToDto.listToListDto(vehicles);
		return new ResponseEntity<List<VehicleDto>>(dto, HttpStatus.OK);
	}
	
	@GetMapping("/year")
	public ResponseEntity<List<VehicleDto>> findByModelYear(@RequestParam(name = "year") Integer year){
		List<Vehicle> vehicles = service.findByModelYear(year);
		List<VehicleDto> dto = VehicleToDto.listToListDto(vehicles);
		return new ResponseEntity<List<VehicleDto>>(dto, HttpStatus.OK);
	}
	
	@GetMapping("/category")
	public ResponseEntity<List<VehicleDto>> findByCategory(@RequestParam(name = "category") Integer category){
		List<Vehicle> vehicles = service.findByCategory(category);
		List<VehicleDto> dto = VehicleToDto.listToListDto(vehicles);
		return new ResponseEntity<List<VehicleDto>>(dto, HttpStatus.OK);
	}
	
	@PostMapping
	public ResponseEntity<VehicleDto> save(@RequestBody @Valid VehicleWrapperDto entityWrapper){
		try {
			Vehicle obj = service.save(entityWrapper.getVeiculo(), entityWrapper.getOwner());
			VehicleDto dto = VehicleToDto.entityToDto(obj);
			return new ResponseEntity<VehicleDto>(dto, HttpStatus.CREATED);
		}
		catch (NullPointerException e) {
			throw new InvalidParametersException("Vehicle requires an owner");
		}
	}
	
	@DeleteMapping("/{id}")
	public ResponseEntity<Void> deleteById(@PathVariable Long id){
		service.deleteById(id);
		return new ResponseEntity<Void>(HttpStatus.NO_CONTENT);
	}
	
	@PutMapping("/{id}")
	public ResponseEntity<VehicleDto> update(@RequestBody @Valid Vehicle obj, @PathVariable(name = "id") Long id){
		try {
		Vehicle vehicle = service.update(obj, id);
		VehicleDto dto = VehicleToDto.entityToDto(vehicle);
		return new ResponseEntity<VehicleDto>(dto, HttpStatus.OK);
		}
		catch (Exception e) {
			throw new InvalidParametersException("parameters do not meet conditions");
		}
	}
	
}
