package br.com.richardeveloper.models.dto;

import java.io.Serializable;

import br.com.richardeveloper.enums.Gender;
import br.com.richardeveloper.models.Owner;

public class OwnerDto implements Serializable {
	private static final long serialVersionUID = 1L;
	
	private Long id;
	private String firstName;
	private String lastName;
	private String cpf;
	private String email;
	private String phone;
	private Gender gender;
	
	public OwnerDto(Owner owner) {
		this.id = owner.getId();
		this.firstName = owner.getFirstName();
		this.lastName = owner.getLastName();
		this.cpf = owner.getCpf();
		this.email = owner.getEmail();
		this.phone = owner.getPhone();
		this.gender = owner.getGender();
	}

	public Long getId() {
		return id;
	}

	public String getFirstName() {
		return firstName;
	}

	public String getLastName() {
		return lastName;
	}

	public String getCpf() {
		return cpf;
	}

	public String getEmail() {
		return email;
	}

	public String getPhone() {
		return phone;
	}

	public Gender getGender() {
		return gender;
	}
	
}
