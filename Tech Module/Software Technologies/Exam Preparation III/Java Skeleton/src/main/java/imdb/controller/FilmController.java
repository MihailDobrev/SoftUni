package imdb.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import imdb.bindingModel.FilmBindingModel;
import imdb.entity.Film;
import imdb.repository.FilmRepository;

import java.util.List;

@Controller
public class FilmController {

    private final FilmRepository filmRepository;

    @Autowired
    public FilmController(FilmRepository filmRepository) {
        this.filmRepository=filmRepository;
    }

    @GetMapping("/")
    public String index(Model model) {
        List<Film> films = filmRepository.findAll();
        model.addAttribute("films", films);
        model.addAttribute("view", "film/index");

        return "base-layout";

    }

	@GetMapping("/create")
	public String create(Model model) {

        model.addAttribute("view", "film/create");
        return "base-layout";

    }

	@PostMapping("/create")
	public String createProcess(Model model, FilmBindingModel filmBindingModel) {
        if (filmBindingModel == null) {
            return "redirect:/";
        }
        if (filmBindingModel.getName().equals("") ||
                filmBindingModel.getGenre().equals("") ||
                filmBindingModel.getDirector().equals("")) {
            return "redirect:/";
        }

        Film film = new Film(filmBindingModel.getName(), filmBindingModel.getGenre(), filmBindingModel.getDirector(), filmBindingModel.getYear());

        filmRepository.saveAndFlush(film);

        model.addAttribute("view");

        return "redirect:/";

    }

	@GetMapping("/edit/{id}")
	public String edit(Model model, @PathVariable int id) {
        Film film = filmRepository.findOne(id);
        if (film!=null) {
            model.addAttribute("film",film);
            model.addAttribute("view", "film/edit");
            return "base-layout";
        }
        return "redirect:/";

    }

	@PostMapping("/edit/{id}")
	public String editProcess(Model model, @PathVariable int id, Film filmModel) {
        if (filmModel.getName().equals("") ||
                filmModel.getGenre().equals("")||
                filmModel.getDirector().equals("")) {
            filmModel.setId(id);
            model.addAttribute("film", filmModel);
            model.addAttribute("view", "film/edit");
            return "base-layout";
        }

        Film task = filmRepository.findOne(id);
        if (task!=null) {
            task.setName(filmModel.getName());
            task.setGenre(filmModel.getGenre());
            task.setDirector(filmModel.getDirector());
            task.setYear(filmModel.getYear());
            filmRepository.saveAndFlush(task);
        }
        return "redirect:/";

        }

	@GetMapping("/delete/{id}")
	public String delete(Model model, @PathVariable int id) {
        Film film=filmRepository.findOne(id);

        if (film==null) {
            return "redirect:/";
        }

        model.addAttribute("view", "film/delete");
        model.addAttribute("film", film);

        return "base-layout";

    }

	@PostMapping("/delete/{id}")
	public String deleteProcess(@PathVariable int id) {
        Film film=filmRepository.findOne(id);

        if (film==null) {
            return "redirect:/";
        }
        filmRepository.delete(film);
        filmRepository.flush();
        return "redirect:/";

    }
}
