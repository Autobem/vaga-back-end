package br.com.richardeveloper.security.services;

import java.util.Date;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.security.core.Authentication;
import org.springframework.stereotype.Service;

import br.com.richardeveloper.security.models.Usuario;
import io.jsonwebtoken.Claims;
import io.jsonwebtoken.Jwts;
import io.jsonwebtoken.SignatureAlgorithm;

@Service
public class TokenService {

	@Value("${api.jwt.expiration}")
	private String expiration;
	
	@Value("${api.jwt.secret}")
	private String secret;
	
	public String generateToken(Authentication authentication) {	
		
		Usuario user = (Usuario) authentication.getPrincipal();
		Date now = new Date();
		Date expirationDate = new Date(now.getTime() + Long.parseLong(expiration));
		
		return Jwts.builder()
				.setIssuer("Richardeveloper API")
				.setSubject(user.getId().toString())
				.setIssuedAt(now)
				.setExpiration(expirationDate)
				.signWith(SignatureAlgorithm.HS256, secret)
				.compact();
	}

	public boolean isTokenValido(String token) {
		try {
			Jwts.parser().setSigningKey(this.secret).parseClaimsJws(token);
			return true;
		}catch (Exception e) {
			return false;
		}
	}

	public Long getIdUsuario(String token) {
		Claims claims = Jwts.parser().setSigningKey(this.secret).parseClaimsJws(token).getBody();
		return Long.parseLong(claims.getSubject());
	}

}
