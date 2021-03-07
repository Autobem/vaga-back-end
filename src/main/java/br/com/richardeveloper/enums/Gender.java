package br.com.richardeveloper.enums;

import br.com.richardeveloper.resources.exceptions.ResourceNotFoundException;

public enum Gender {

	MALE(0),
	FEMALE(1),
	UNDEFINED(2);
	
	private Gender(int code) {
		this.code = code;
	}
	
	private int code;
	
	public int getCode() {
		return code;
	}
	
	public static Gender getGender(int value) {
		for (Gender item : Gender.values()) {
			if(item.getCode() == value) {
				return item;
			}
		}
		throw new ResourceNotFoundException("Gender not exist.");
	}
}
