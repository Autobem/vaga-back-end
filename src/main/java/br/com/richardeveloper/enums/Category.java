package br.com.richardeveloper.enums;

import br.com.richardeveloper.resources.exceptions.ResourceNotFoundException;

public enum Category {
	
	MOTORCYCLE(0),
	CAR(1),
	TRUCK(2);
	
	private int code;
	
	private Category(int code) {
		this.code = code;
	}
	
	public int getCode() {
		return code;
	}
	
	public static Category getCategory(int value) {
		for (Category item : Category.values()) {
			if(value == item.getCode()) {
				return item;
			}
		}
		throw new ResourceNotFoundException("Category not exist.");
	}

}
