package br.com.richardeveloper.configs;

import java.util.Arrays;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.Profile;

import br.com.richardeveloper.enums.Category;
import br.com.richardeveloper.enums.Gender;
import br.com.richardeveloper.models.Owner;
import br.com.richardeveloper.models.Vehicle;
import br.com.richardeveloper.repositories.OwnerRepository;
import br.com.richardeveloper.repositories.VehicleRepository;
import br.com.richardeveloper.security.models.Usuario;
import br.com.richardeveloper.security.repositories.UsuarioRepository;

@Configuration
@Profile(value = "test")
public class TestConfig implements CommandLineRunner {

	@Autowired
	private OwnerRepository proprietarioRepository;
	
	@Autowired
	private VehicleRepository veiculoRepository;
	
	@Autowired
	private UsuarioRepository usuarioRepository;
	
	@Override
	public void run(String... args) throws Exception {
	
		Owner p1 = new Owner(null, "João", "Almeida", "15054983090", "joao@email.com", "992365471", Gender.MALE);
		Owner p2 = new Owner(null, "Maria", "Ferreira", "57711380020", "mary@email.com", "985236495", Gender.FEMALE);
		Owner p3 = new Owner(null, "Francisco", "Alves", "84481430001", "francisco@email.com", "998456327", Gender.MALE);
		Owner p4 = new Owner(null, "Bruna", "Rodrigues", "87932764009", "bruna@email.com", "992149875", Gender.FEMALE);
		Owner p5 = new Owner(null, "Fernando", "Ribeiro", "85198726036", "fernando@email.com", "985236547", Gender.MALE);
		
		Vehicle v1 = new Vehicle(null, "RX 350 ", "Lexus", 2012, Category.CAR);
		Vehicle v2 = new Vehicle(null, "Grand Cherokee Limited ", "Jeep", 2020, Category.CAR);
		Vehicle v3 = new Vehicle(null, "Expedition Limited", "Ford", 2016, Category.CAR);
		Vehicle v4 = new Vehicle(null, "Fusion SE", "Ford", 2017, Category.CAR);
		Vehicle v5 = new Vehicle(null, "Cruze LT", "Chevrolet", 2019, Category.CAR);
		Vehicle v6 = new Vehicle(null, "Spark LS", "Chevrolet", 2018, Category.CAR);
 		
		Vehicle v7 = new Vehicle(null, "CB 250 F Twister", "Honda", 2019, Category.MOTORCYCLE);
		Vehicle v8 = new Vehicle(null, "Breakout 114", "Harley-Davidson", 2019, Category.MOTORCYCLE);
		
		Vehicle v9 = new Vehicle(null, "Delivery Express", "Volkswagen", 2021, Category.TRUCK);
		Vehicle v10 = new Vehicle(null, "Tector 9-190 Chassi", "Iveco", 2020, Category.TRUCK);
		
		proprietarioRepository.saveAll(Arrays.asList(p1, p2, p3, p4, p5));
				
		veiculoRepository.saveAll(Arrays.asList(v1, v2, v3, v4, v5, v6, v7, v8, v9, v10));
		
		p1.addVeiculo(v1);
		p1.addVeiculo(v2);
		p1.addVeiculo(v3);	
		p2.addVeiculo(v4);
		p2.addVeiculo(v5);
		p3.addVeiculo(v6);	
		p4.addVeiculo(v7);
		p4.addVeiculo(v8);
		p5.addVeiculo(v9);
		p5.addVeiculo(v10);
				
		proprietarioRepository.saveAll(Arrays.asList(p1, p2, p3, p4, p5));
		
		v1.setOwner(p1);
		v2.setOwner(p1);
		v3.setOwner(p1);
		v4.setOwner(p2);
		v5.setOwner(p2);
		v6.setOwner(p3);
		v7.setOwner(p4);
		v8.setOwner(p4);
		v9.setOwner(p5);
		v10.setOwner(p5);
		
		veiculoRepository.saveAll(Arrays.asList(v1, v2, v3, v4, v5, v6, v7, v8, v9, v10));
		
		Usuario u1 = new Usuario();
		u1.setName("User");
		u1.setEmail("user@email.com");
		u1.setSenha("$2a$10$GYaceEEom.SFjpMgmkZleu7LE96ACenr/Zhk/fO2m3W5ZZ3nnXS2u");
		
		Usuario u2 = new Usuario();
		u2.setName("Autobem");
		u2.setEmail("autobem@email.com");
		u2.setSenha("$2a$10$mEXv6u/qy1/QBV9SNR7NKead0jSBWcTUDbVJK2BDisxVEbxdonJUy");
		
		usuarioRepository.saveAll(Arrays.asList(u1, u2));
		
		
	}

}
