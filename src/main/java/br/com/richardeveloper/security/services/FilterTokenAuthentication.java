package br.com.richardeveloper.security.services;

import java.io.IOException;

import javax.servlet.FilterChain;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.web.filter.OncePerRequestFilter;

import br.com.richardeveloper.security.models.Usuario;
import br.com.richardeveloper.security.repositories.UsuarioRepository;

public class FilterTokenAuthentication extends OncePerRequestFilter{
	
	private UsuarioRepository repository;
	private TokenService tokenService;
	
	public FilterTokenAuthentication(TokenService tokenService, UsuarioRepository repository) {
		this.tokenService = tokenService;
		this.repository = repository;
	}
	
	@Override
	protected void doFilterInternal(HttpServletRequest request, HttpServletResponse response, FilterChain filterChain)
			throws ServletException, IOException {
		
		String token = requestToken(request);
		boolean valido = tokenService.isTokenValido(token);
		if(valido) {
			userAuthentication(token);
		}
		filterChain.doFilter(request, response);
	}

	private void userAuthentication(String token) {
		Long id = tokenService.getIdUsuario(token);
		Usuario usuario = repository.findById(id).get();
		UsernamePasswordAuthenticationToken authentication = new UsernamePasswordAuthenticationToken
				(usuario, null, usuario.getAuthorities());
		SecurityContextHolder.getContext().setAuthentication(authentication);
		
	}

	private String requestToken(HttpServletRequest request) {
		String token = request.getHeader("Authorization");
		if(token == null || token.isEmpty() || !token.startsWith("Bearer ")) {
			return null;
		}
		return token.substring(7, token.length());
	}

}
