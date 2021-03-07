package br.com.richardeveloper.services.exceptions;

import java.time.Instant;
import java.util.ArrayList;
import java.util.List;

import javax.security.sasl.AuthenticationException;
import javax.servlet.http.HttpServletRequest;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.MessageSource;
import org.springframework.context.i18n.LocaleContextHolder;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.http.converter.HttpMessageNotReadableException;
import org.springframework.validation.FieldError;
import org.springframework.web.bind.MethodArgumentNotValidException;
import org.springframework.web.bind.MissingServletRequestParameterException;
import org.springframework.web.bind.UnsatisfiedServletRequestParameterException;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.RestControllerAdvice;
import org.springframework.web.method.annotation.MethodArgumentTypeMismatchException;

import br.com.richardeveloper.errors.GenericError;
import br.com.richardeveloper.errors.StandardError;
import br.com.richardeveloper.resources.exceptions.DatabaseException;
import br.com.richardeveloper.resources.exceptions.InvalidParametersException;
import br.com.richardeveloper.resources.exceptions.ResourceNotFoundException;

@RestControllerAdvice
public class ResourceExceptionHandler {
	
	@Autowired
	private MessageSource messageSource;

	@ExceptionHandler(ResourceNotFoundException.class)
	public ResponseEntity<StandardError> resourceNotFound(ResourceNotFoundException e, HttpServletRequest request){
		String err = "The requested resource does not exist.";
		HttpStatus status = HttpStatus.NOT_FOUND;
		
		StandardError error = new StandardError(
									Instant.now(), 
									status.value(),
									err, 
									e.getMessage(), 
									request.getRequestURI());
		
		return new ResponseEntity<StandardError>(error, status);
	}
	
	@ExceptionHandler(DatabaseException.class)
	public ResponseEntity<StandardError> databaseError(DatabaseException e, HttpServletRequest request){
		String err = "Database error.";
		HttpStatus status = HttpStatus.BAD_REQUEST;
		
		StandardError error = new StandardError(
									Instant.now(), 
									status.value(),
									err, 
									e.getMessage(), 
									request.getRequestURI());
		
		return new ResponseEntity<StandardError>(error, status);
	}
	
	@ExceptionHandler(InvalidParametersException.class)
	public ResponseEntity<StandardError> databaseError(InvalidParametersException e, HttpServletRequest request){
		String err = "Paremeter error.";
		HttpStatus status = HttpStatus.BAD_REQUEST;
		
		StandardError error = new StandardError(
				Instant.now(), 
				status.value(),
				err, 
				e.getMessage(), 
				request.getRequestURI());
		
		return new ResponseEntity<StandardError>(error, status);
	}
	
	@ExceptionHandler(MissingServletRequestParameterException.class)
	public ResponseEntity<StandardError> parameterError(MissingServletRequestParameterException e, HttpServletRequest request){
		String err = "Parameters error.";
		HttpStatus status = HttpStatus.BAD_REQUEST;
		
		StandardError error = new StandardError(
									Instant.now(), 
									status.value(),
									err, 
									e.getMessage(), 
									request.getRequestURI());
		
		return new ResponseEntity<StandardError>(error, status);
	}
	
	@ExceptionHandler(MethodArgumentTypeMismatchException.class)
	public ResponseEntity<StandardError> argumentNotValid(MethodArgumentTypeMismatchException e, HttpServletRequest request){
		String err = "The Argument is not valid";
		HttpStatus status = HttpStatus.NOT_FOUND;
		
		StandardError error = new StandardError(
									Instant.now(), 
									status.value(), 
									err, 
									e.getMessage(), 
									request.getRequestURI());
		
		return new ResponseEntity<StandardError>(error, status);
	}
	
	@ExceptionHandler(HttpMessageNotReadableException.class)
	public ResponseEntity<StandardError> httpReadable(HttpMessageNotReadableException e, HttpServletRequest request){
		String err = "";
		HttpStatus status = HttpStatus.BAD_REQUEST;
		
		StandardError error = new StandardError(
				Instant.now(), 
				status.value(), 
				err, 
				e.getMessage(), 
				request.getRequestURI());
		
		return new ResponseEntity<StandardError>(error, status);
	}
	
	@ExceptionHandler(UnsatisfiedServletRequestParameterException.class)
	public ResponseEntity<StandardError> unsatisfiedConditions(UnsatisfiedServletRequestParameterException e, HttpServletRequest request){
		String err = "Requisition conditions were not met ";
		HttpStatus status = HttpStatus.BAD_REQUEST;
		
		StandardError error = new StandardError(
				Instant.now(), 
				status.value(), 
				err, 
				e.getMessage(), 
				request.getRequestURI());
		
		return new ResponseEntity<StandardError>(error, status);
	}
	
	
	@ExceptionHandler(AuthenticationException.class)
	public ResponseEntity<StandardError> httpReadable(AuthenticationException e, HttpServletRequest request){
		String err = "Authentication Failed";
		HttpStatus status = HttpStatus.BAD_REQUEST;
		
		StandardError error = new StandardError(
				Instant.now(), 
				status.value(), 
				err, 
				e.getMessage(), 
				request.getRequestURI());
		
		return new ResponseEntity<StandardError>(error, status);
	}
	
	@ExceptionHandler(MethodArgumentNotValidException.class)
	public ResponseEntity<List<GenericError>> validationHandler(MethodArgumentNotValidException exception){
		List<GenericError> errors = new ArrayList<GenericError>();

		List<FieldError> fieldErrors = exception.getBindingResult().getFieldErrors();
		
		fieldErrors.stream().forEach( (e) -> {
			String message = messageSource.getMessage(e, LocaleContextHolder.getLocale());
			GenericError error = new GenericError(e.getField(), message);
			errors.add(error);
		});
		
		return new ResponseEntity<List<GenericError>>(errors, HttpStatus.BAD_REQUEST);
	}
}
