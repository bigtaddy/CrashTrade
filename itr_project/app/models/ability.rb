class Ability
  include CanCan::Ability

  def initialize(user)
    user ||= User.new

    if user.role? :admin
      can :resolvedtasks, :all
     # can :manage, Task
      can :destroy, :all
      can :resolve, Task do |task|
          !(task.passed_users.include?( user )) & !(task.try(:creator) == user)
        end
      can :create, :all
      can :get_tags, :all
      can :edit, :all
      can :update, :all
      can :vote, Task do |task|
          !(task.voted_by?(user)) & !(task.try(:creator) == user)
        end
      can :read, :all

    else
      can :read, :all
      if user.role?(:user)
        can :vote, Task do |task|
          !(task.voted_by?(user)) & !(task.try(:creator) == user)
        end
        can :passedusers, Task
        can :resolve, Task do |task|
          !(task.passed_users.include?( user )) & !(task.try(:creator) == user)
        end
        can :create, Task
        can :get_tags, Task
        can :edit, Profile do |profile|
          profile.try(:user) == user
        end

        can :update, Profile do |profile|
          profile.try(:user) == user
        end

        can :update, Task do |task|
          task.try(:creator) == user
        end
        can :destroy, Task do |task|
          task.try(:creator) == user
        end
      end
    end
    
    # Define abilities for the passed in user here. For example:
    #
    #   user ||= User.new # guest user (not logged in)
    #   if user.admin?
    #     can :manage, :all
    #   else
    #     can :read, :all
    #   end
    #
    # The first argument to `can` is the action you are giving the user permission to do.
    # If you pass :manage it will apply to every action. Other common actions here are
    # :read, :create, :update and :destroy.
    #
    # The second argument is the resource the user can perform the action on. If you pass
    # :all it will apply to every resource. Otherwise pass a Ruby class of the resource.
    #
    # The third argument is an optional hash of conditions to further filter the objects.
    # For example, here the user can only update published articles.
    #
    #   can :update, Article, :published => true
    #
    # See the wiki for details: https://github.com/ryanb/cancan/wiki/Defining-Abilities
  end
end
