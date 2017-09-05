const Film = require('../models/Film');

module.exports = {
	index: (req, res) => {
        Film.find().then(films => {
            res.render('film/index', {'films': films})
        });

    },
	createGet: (req, res) => {
        res.render('film/create');
	},
	createPost: (req, res) => {
        let filmArgs = req.body;

        if (filmArgs.name === undefined ||
			filmArgs.genre === undefined ||
			filmArgs.director === undefined ||
			filmArgs.year === undefined) {
            res.redirect('/');
            return;
        }

        Film.create(filmArgs).then(film => {
            res.redirect('/');
        }).catch(err=>{
            filmArgs.error='Cannot create film.';
            res.render('film/create',film);
        });

    },
	editGet: (req, res) => {
        let filmId=req.params.id;
        Film.findById(filmId).then(film=>{
            if (film) {
                return res.render('film/edit', film);
            }
            else {
                return res.redirect('/');
            }
        }).catch(err=>res.redirect('/'));
    },
	editPost: (req, res) => {
        let filmId=req.params.id;
        let film=req.body;

        Film.findByIdAndUpdate(filmId,film, {runValidators:
            true}).then(films=> {
            res.redirect("/");
        }).catch(err=>{
            film.id = filmId;
            film.error = "Cannot edit film.";
            return res.render("film/edit",film);
        });

    },
	deleteGet: (req, res) => {
        let id = req.params.id;

        Film.findById(id).then(film=>{
            if (!film) {
                res.redirect('/');
                return;
            }

            res.render('film/delete', film)
        })
        if (!id) {
            res.redirect('/');
            return;
        }
    },
	deletePost: (req, res) => {
        let id = req.params.id;

        Film.findByIdAndRemove(id).then(film=> {
            res.redirect('/');
        });

    }
};