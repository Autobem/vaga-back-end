package br.com.richardeveloper.security.config;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.http.HttpMethod;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.builders.WebSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter;
import org.springframework.security.config.http.SessionCreationPolicy;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.web.authentication.UsernamePasswordAuthenticationFilter;

import br.com.richardeveloper.security.repositories.UsuarioRepository;
import br.com.richardeveloper.security.services.FilterTokenAuthentication;
import br.com.richardeveloper.security.services.TokenService;

@EnableWebSecurity
@Configuration
public class SecurityConfigurations extends WebSecurityConfigurerAdapter {
	
	@Autowired
	private AuthenticationService authenticationService;
	
	@Autowired
	private TokenService tokenService;
	
	@Autowired
	private UsuarioRepository usuarioRepository;
	
	@Override
	@Bean
	protected AuthenticationManager authenticationManager() throws Exception {
		return super.authenticationManager();
	}
	
	//AUTHENTICATION CONFIGS
	@Override
	protected void configure(AuthenticationManagerBuilder auth) throws Exception {
		auth.userDetailsService(authenticationService).passwordEncoder(new BCryptPasswordEncoder());
	}

	//AUTHORIZATION CONFIGS
	@Override
	protected void configure(HttpSecurity http) throws Exception {
		http.authorizeRequests()
		.antMatchers(HttpMethod.GET, "/vehicles").permitAll()
		.antMatchers(HttpMethod.GET, "/vehicles/*").permitAll()
		.antMatchers(HttpMethod.GET, "/owners").permitAll()
		.antMatchers(HttpMethod.GET, "/owners/*").permitAll()
		.antMatchers(HttpMethod.POST, "/auth").permitAll()
		.anyRequest().authenticated()
		.and().csrf().disable()
		.sessionManagement().sessionCreationPolicy(SessionCreationPolicy.STATELESS)
		.and().addFilterBefore(new FilterTokenAuthentication(this.tokenService, this.usuarioRepository), UsernamePasswordAuthenticationFilter.class);
	}
	
	//STATICS RESOURCES CONFIG(JS, CSS, IMAGE...)
	@Override
	public void configure(WebSecurity web) throws Exception {
		 web.ignoring()
	        .antMatchers("/**.html", 
	        		"/v2/api-docs", 
	        		"/webjars/**", 
	        		"/configuration/**", 
	        		"/swagger-resources/**");
	}
	

}
