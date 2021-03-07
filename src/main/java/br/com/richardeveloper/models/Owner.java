package br.com.richardeveloper.models;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.validation.constraints.Email;
import javax.validation.constraints.NotEmpty;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;

import org.hibernate.validator.constraints.br.CPF;

import br.com.richardeveloper.enums.Gender;

@Entity
@Table(name = "tb_owner")
public class Owner implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private Long id;
	
	@NotEmpty(message = "Field first name cannot be empty.")
	private String firstName;
	
	@NotEmpty(message = "Field last name cannot be empty.")
	private String lastName;
	
	@CPF
	@NotEmpty(message = "Field CPF cannot be empty.")
	private String cpf;
	
	@Email
	@NotEmpty(message = "Field e-mail cannot be empty.")
	private String email;
	
	@NotEmpty
	@Size(min = 8, max = 9)
	private String phone;
	
	@NotNull(message = "Field gender cannot be empty.")
	private Integer gender;
	
	@OneToMany(fetch = FetchType.LAZY, mappedBy = "owner")
	private List<Vehicle> vehicles = new ArrayList<Vehicle>();
	
	public Owner() {
	
	}

	public Owner(Long id, String firstName, String lastName, String cpf, String email, String phone, Gender gender) {
		this.id = id;
		this.firstName = firstName;
		this.lastName = lastName;
		this.cpf = cpf;
		this.email = email;
		this.phone = phone;
		this.setGender(gender);
	}
	
	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getFirstName() {
		return firstName;
	}

	public void setFirstName(String firstName) {
		this.firstName = firstName;
	}

	public String getLastName() {
		return lastName;
	}

	public void setLastName(String lastName) {
		this.lastName = lastName;
	}

	public String getCpf() {
		return cpf;
	}

	public void setCpf(String cpf) {
		this.cpf = cpf;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getPhone() {
		return phone;
	}

	public void setPhone(String phone) {
		this.phone = phone;
	}

	public Gender getGender() {
		return Gender.getGender(this.gender);
	}

	public void setGender(Gender gender) {
		this.gender = gender.getCode();
	}
	
	public List<Vehicle> getVehicles(){
		return this.vehicles;
	}
	
	public void addVeiculo(Vehicle vehicle) {
		this.vehicles.add(vehicle);
	}
	
	public void removeVeiculo(Vehicle vehicle) {
		this.vehicles.remove(vehicle);
	}

	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + ((id == null) ? 0 : id.hashCode());
		return result;
	}

	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		Owner other = (Owner) obj;
		if (id == null) {
			if (other.id != null)
				return false;
		} else if (!id.equals(other.id))
			return false;
		return true;
	}

	@Override
	public String toString() {
		return "Owner [id=" + id + ", firstName=" + firstName + ", lastName=" + lastName + ", cpf=" + cpf + ", email="
				+ email + ", phone=" + phone + ", gender=" + gender + ", vehicles=" + vehicles + "]";
	}
	
}
