package br.com.richardeveloper.security.services;

import javax.naming.AuthenticationException;
import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.Authentication;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseStatus;
import org.springframework.web.bind.annotation.RestController;

import br.com.richardeveloper.security.dto.LoginFormDto;
import br.com.richardeveloper.security.dto.TokenDto;

@RestController
@RequestMapping("/auth")
public class AuthenticationController {

	@Autowired
	private AuthenticationManager authenticationManager;

	@Autowired
	private TokenService tokenService;

	@PostMapping
	@ResponseStatus(code = HttpStatus.BAD_REQUEST)
	public ResponseEntity<TokenDto> authentication(@RequestBody @Valid LoginFormDto form) throws AuthenticationException {
		UsernamePasswordAuthenticationToken dadosLogin = form.convertData();

		Authentication authentication = authenticationManager.authenticate(dadosLogin);
		String t = tokenService.generateToken(authentication);
		return ResponseEntity.ok(new TokenDto(t, "Bearer"));
		
	}
	
}
