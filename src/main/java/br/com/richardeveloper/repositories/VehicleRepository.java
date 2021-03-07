package br.com.richardeveloper.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import br.com.richardeveloper.models.Vehicle;

@Repository
public interface VehicleRepository extends JpaRepository<Vehicle, Long>{
	
	@Query("SELECT v FROM Vehicle v WHERE v.brand LIKE ?1%")
	public List<Vehicle> findByBrand(String brand);

	@Query("SELECT v FROM Vehicle v WHERE v.model LIKE ?1%")
	public List<Vehicle> findByModel(String model);
	
	public List<Vehicle> findByModelYear(Integer modelYear);
	
	public List<Vehicle> findByCategory(Integer category);
		
}
