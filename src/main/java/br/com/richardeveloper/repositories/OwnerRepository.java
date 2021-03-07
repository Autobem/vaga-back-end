package br.com.richardeveloper.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import br.com.richardeveloper.models.Owner;

@Repository
public interface OwnerRepository extends JpaRepository<Owner, Long>{

	@Query("SELECT o FROM Owner o WHERE o.firstName LIKE ?1%")
	public List<Owner> findByFirstName(String firstName);
	
	@Query("SELECT o FROM Owner o WHERE o.firstName like ?1% AND o.lastName LIKE ?2%")
	public Owner findByFullName(String firstName, String lastName);
	
	public List<Owner> findByGender(Integer gender);
}
