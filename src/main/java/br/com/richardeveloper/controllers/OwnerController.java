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

import br.com.richardeveloper.models.Owner;
import br.com.richardeveloper.models.Vehicle;
import br.com.richardeveloper.models.dto.OwnerDto;
import br.com.richardeveloper.models.dto.OwnerToDto;
import br.com.richardeveloper.models.dto.OwnerWrapperDto;
import br.com.richardeveloper.resources.exceptions.DatabaseException;
import br.com.richardeveloper.services.OwnerService;

@RestController
@RequestMapping("/owners")
public class OwnerController {

	@Autowired
	private OwnerService service;
	
	@GetMapping(params = { "page", "qtd" })
	public ResponseEntity<Page<OwnerDto>> findAllPagination(@RequestParam(name = "page") int page, @RequestParam(name = "qtd") int qtd){
		Page<Owner> owners = service.findAllPagination(page, qtd);
		Page<OwnerDto> dto = owners.map((obj) -> OwnerToDto.entityToDto(obj));
		return new ResponseEntity<Page<OwnerDto>>(dto, HttpStatus.OK);	
	}
	
	@GetMapping("/{id}")
	public ResponseEntity<OwnerDto> findById(@PathVariable Long id){
		Owner owner = service.findById(id);
		OwnerDto dto = OwnerToDto.entityToDto(owner);
		return new ResponseEntity<OwnerDto>(dto, HttpStatus.OK);
	}
	
	@GetMapping(path = "/owner", params = {"id"})
	public ResponseEntity<OwnerWrapperDto> findOwnerAndVehicles(@RequestParam(name = "id") Long id){
		Owner owner = service.findById(id);
		List<Vehicle> vehicles = owner.getVehicles();
		OwnerWrapperDto dto = new OwnerWrapperDto(owner, vehicles);
		return new ResponseEntity<OwnerWrapperDto>(dto, HttpStatus.OK);
	}
	
	@GetMapping(params = {"name"})
	public ResponseEntity<List<OwnerDto>> findByFirstName(@RequestParam(name = "name") String name){
		List<Owner> owners = service.findByFirstName(name);
		List<OwnerDto> dto = OwnerToDto.listToListDto(owners);
		return new ResponseEntity<List<OwnerDto>>(dto, HttpStatus.OK);
	}
	
	@GetMapping(params = {"first", "last"})
	public ResponseEntity<OwnerDto> findByFullName(@RequestParam(name = "first") String firstName, 
											@RequestParam(name = "last") String lastName){
		try{
			Owner owner = service.findByFullName(firstName, lastName);
			OwnerDto dto = OwnerToDto.entityToDto(owner);
			return new ResponseEntity<OwnerDto>(dto, HttpStatus.OK);
		}
		catch(Exception e) {
			throw new DatabaseException("Owner "+firstName+" "+lastName+" not exist");
		}
	}
	
	@GetMapping("/gender")
	public ResponseEntity<List<OwnerDto>> findByGender(@RequestParam(name = "gender") Integer gender){
		List<Owner> owners = service.findByGender(gender);
		List<OwnerDto> dto = OwnerToDto.listToListDto(owners);
		return new ResponseEntity<List<OwnerDto>>(dto, HttpStatus.OK);
	}

	@PostMapping
	public ResponseEntity<OwnerDto> save(@RequestBody @Valid Owner obj){
		Owner owner = service.save(obj);
		OwnerDto dto = OwnerToDto.entityToDto(owner);
		return new ResponseEntity<OwnerDto>(dto, HttpStatus.CREATED);
	}
	
	@DeleteMapping("/{id}")
	public ResponseEntity<Void> deleteById(@PathVariable Long id){
		service.deleteById(id);
		return new ResponseEntity<Void>(HttpStatus.NO_CONTENT);
	}
	
	@PutMapping("/{id}")
	public ResponseEntity<OwnerDto> update(@RequestBody @Valid Owner obj, @PathVariable Long id){
		Owner owner = service.update(obj, id);
		OwnerDto dto = OwnerToDto.entityToDto(owner);
		return new ResponseEntity<OwnerDto>(dto, HttpStatus.OK);
	}
}
