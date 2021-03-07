package br.com.richardeveloper.services;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.dao.DataIntegrityViolationException;
import org.springframework.dao.EmptyResultDataAccessException;
import org.springframework.dao.InvalidDataAccessApiUsageException;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.stereotype.Service;

import br.com.richardeveloper.models.Owner;
import br.com.richardeveloper.models.Vehicle;
import br.com.richardeveloper.repositories.VehicleRepository;
import br.com.richardeveloper.resources.exceptions.DatabaseException;
import br.com.richardeveloper.resources.exceptions.ResourceNotFoundException;

@Service
public class VehicleService {

	@Autowired
	private VehicleRepository repository;

	public Page<Vehicle> findAllPagination(int page, int qtd) {
		Pageable pagination = PageRequest.of(page, qtd);

		Page<Vehicle> vehicles = repository.findAll(pagination);

		return vehicles;
	}

	public Vehicle findById(Long id) {
		Optional<Vehicle> vehicle = repository.findById(id);
		return vehicle.orElseThrow(() -> new ResourceNotFoundException(id));
	}

	public List<Vehicle> findByBrand(String brand) {
		List<Vehicle> vehicles = repository.findByBrand(brand);
		return vehicles;
	}

	public List<Vehicle> findByModel(String model) {
		List<Vehicle> vehicles = repository.findByModel(model);
		return vehicles;
	}

	public List<Vehicle> findByModelYear(Integer modelYear) {
		List<Vehicle> vehicles = repository.findByModelYear(modelYear);
		return vehicles;
	}
	
	public List<Vehicle> findByCategory(Integer category) {
		List<Vehicle> vehicles = repository.findByCategory(category);
		return vehicles;
	}

	public Vehicle save(Vehicle obj, Owner owner) {
		try {
			obj.setOwner(owner);
			Vehicle vehicle = repository.save(obj);
			return vehicle;
		} catch (InvalidDataAccessApiUsageException e) {
			throw new DatabaseException(e.getMessage());
		}

	}

	public void deleteById(Long id) {
		try {
			repository.deleteById(id);
		} catch (DataIntegrityViolationException | EmptyResultDataAccessException e) {
			throw new DatabaseException(e.getMessage());
		}

	}

	public Vehicle update(Vehicle obj, Long id) {
		return repository.findById(id).map((vehicle) -> {
			this.updateData(vehicle, obj);
			return repository.save(vehicle);
		}).orElseThrow(() -> new ResourceNotFoundException(id));
	}

	public void updateData(Vehicle vehicle, Vehicle obj) {
		vehicle.setId(obj.getId());
		vehicle.setModel(obj.getModel());
		vehicle.setBrand(obj.getBrand());
		vehicle.setModelYear(obj.getModelYear());
		vehicle.setCategory(obj.getCategory());
	}


}
