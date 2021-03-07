package br.com.richardeveloper.resources.exceptions;

public class ResourceNotFoundException extends RuntimeException{
	private static final long serialVersionUID = 1L;
	
	public ResourceNotFoundException(Object id) {
		super("Id is not found. Id: "+id);
	}

}
