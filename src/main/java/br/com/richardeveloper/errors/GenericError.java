package br.com.richardeveloper.errors;

import java.io.Serializable;

public class GenericError implements Serializable {
	private static final long serialVersionUID = 1L;
	
	private String field;
	private String message;
	
	public GenericError(String field, String message) {
		this.field = field;
		this.message = message;
	}

	public String getField() {
		return field;
	}
	
	public String getMessage() {
		return message;
	}
	
}
