package todolist.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import todolist.entity.Task;

import java.util.List;

public interface TaskRepository extends JpaRepository<Task, Integer> {

}
