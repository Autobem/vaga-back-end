package br.com.richardeveloper.resources.exceptions;

public class InvalidParametersException extends RuntimeException{
	private static final long serialVersionUID = 1L;
	
	public InvalidParametersException(String mensagem) {
		super(mensagem);
	}
}
