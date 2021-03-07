package br.com.richardeveloper.services;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.dao.DataIntegrityViolationException;
import org.springframework.dao.EmptyResultDataAccessException;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.stereotype.Service;

import br.com.richardeveloper.models.Owner;
import br.com.richardeveloper.repositories.OwnerRepository;
import br.com.richardeveloper.resources.exceptions.DatabaseException;
import br.com.richardeveloper.resources.exceptions.ResourceNotFoundException;

@Service
public class OwnerService {

	@Autowired
	private OwnerRepository repository;
	
	public Page<Owner> findAllPagination(int pagina, int qtd){
		Pageable pagination = PageRequest.of(pagina, qtd);
		
		Page<Owner> owners = repository.findAll(pagination);
		
		return owners;
	}
	
	public List<Owner> findByFirstName(String name){
		List<Owner> owners = repository.findByFirstName(name);
		return owners;
	}
	
	public Owner findByFullName(String firstName, String lastName) {
		Owner owner = repository.findByFullName(firstName, lastName);
		return owner;
	}
	
	public Owner findById(Long id) {
		Optional<Owner> owner = repository.findById(id);
		return owner.orElseThrow( () -> new ResourceNotFoundException(id));
	}
	
	public List<Owner> findByGender(Integer gender) {
		List<Owner> owners = repository.findByGender(gender);
		return owners;
	}
	
	public Owner save(Owner obj) {
		Owner owner = repository.save(obj);
		return owner;
	}
	
	public void deleteById(Long id) {
		try {
			repository.deleteById(id);
		}
		catch (DataIntegrityViolationException | EmptyResultDataAccessException e) {
			throw new DatabaseException(e.getMessage());
		}
	}
	
	public Owner update(Owner obj, Long id) {
		return repository.findById(id)
				.map( (owner) -> {
					this.updateData(owner, obj);
					return repository.save(owner);
				}).orElseThrow( () -> new ResourceNotFoundException(id));
	}
	
	public void updateData(Owner owner, Owner obj) {
		owner.setId(obj.getId());
		owner.setFirstName(obj.getFirstName());
		owner.setLastName(obj.getLastName());
		owner.setCpf(obj.getCpf());
		owner.setEmail(obj.getEmail());
		owner.setPhone(obj.getPhone());
		owner.setGender(obj.getGender());
	}
	
	
}
